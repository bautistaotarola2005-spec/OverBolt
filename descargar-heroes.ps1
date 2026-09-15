<#
    Baja los retratos de heroe de Overwatch a Assets\heroes\ con el nombre que espera
    la aplicacion (la clave del heroe + .png).

    La app NO consulta ninguna API: este script se corre una sola vez para poblar la
    carpeta, y despues las imagenes viajan dentro del repositorio.

    Uso:
        .\descargar-heroes.ps1
        .\descargar-heroes.ps1 -Json .\heroes.json     (si ya lo bajaste)

    Si Windows bloquea la ejecucion:
        powershell -ExecutionPolicy Bypass -File .\descargar-heroes.ps1
#>

param(
    [string]$Json = ""
)

[Net.ServicePointManager]::SecurityProtocol = [Net.SecurityProtocolType]::Tls12

$destino = Join-Path $PSScriptRoot "OverBolt\Assets\heroes"
New-Item -ItemType Directory -Force -Path $destino | Out-Null
Write-Host ""
Write-Host "Destino: $destino" -ForegroundColor DarkGray

# --- catalogo -------------------------------------------------------------
if ($Json -and (Test-Path $Json)) {
    Write-Host "Leyendo el JSON local: $Json" -ForegroundColor Cyan
    $heroes = Get-Content $Json -Raw | ConvertFrom-Json
} else {
    Write-Host "Consultando la API de heroes..." -ForegroundColor Cyan
    try {
        $heroes = Invoke-RestMethod -Uri "https://overfast-api.tekrop.fr/heroes" -UseBasicParsing
    } catch {
        Write-Host "No se pudo consultar la API: $($_.Exception.Message)" -ForegroundColor Red
        Write-Host "Volve a correrlo pasando el JSON que ya tenes:  .\descargar-heroes.ps1 -Json .\heroes.json" -ForegroundColor Yellow
        exit 1
    }
}
Write-Host "  $($heroes.Count) heroes en el catalogo"
Write-Host ""

# --- descarga -------------------------------------------------------------
$bajados = 0
$salteados = 0
$fallados = @()

foreach ($h in $heroes) {
    $archivo = Join-Path $destino "$($h.key).png"

    if (Test-Path $archivo) {
        $salteados++
        continue
    }
    if (-not $h.portrait) {
        $fallados += $h.key
        Write-Host ("  SIN IMAGEN  {0}" -f $h.key) -ForegroundColor Yellow
        continue
    }

    try {
        Invoke-WebRequest -Uri $h.portrait -OutFile $archivo -UseBasicParsing
        $bajados++
        Write-Host ("  OK          {0,-16} {1}" -f $h.key, $h.name) -ForegroundColor Green
    } catch {
        $fallados += $h.key
        Write-Host ("  FALLO       {0,-16} {1}" -f $h.key, $_.Exception.Message) -ForegroundColor Red
    }
}

# --- control: el catalogo de la app contra el de la API -------------------
$enLaApp = @(
    'ana', 'anran', 'ashe', 'baptiste', 'bastion', 'brigitte',
    'cassidy', 'dmon', 'domina', 'doomfist', 'dva', 'echo',
    'emre', 'freja', 'genji', 'hanzo', 'hazard', 'illari',
    'jetpack-cat', 'junker-queen', 'junkrat', 'juno', 'kiriko', 'lifeweaver',
    'lucio', 'mauga', 'mei', 'mercy', 'mizuki', 'moira',
    'orisa', 'pharah', 'ramattra', 'reaper', 'reinhardt', 'roadhog',
    'shion', 'sierra', 'sigma', 'sojourn', 'soldier-76', 'sombra',
    'symmetra', 'torbjorn', 'tracer', 'vendetta', 'venture', 'widowmaker',
    'winston', 'wrecking-ball', 'wuyang', 'zarya', 'zenyatta'
)

$sobranEnApi = @($heroes.key | Where-Object { $enLaApp -notcontains $_ })
$faltanEnApi = @($enLaApp   | Where-Object { $heroes.key -notcontains $_ })

Write-Host ""
Write-Host ("Bajados: {0}   Ya estaban: {1}   Con problema: {2}" -f $bajados, $salteados, $fallados.Count)

if ($sobranEnApi.Count -gt 0) {
    Write-Host ""
    Write-Host "La API trae heroes que la app todavia no conoce:" -ForegroundColor Yellow
    $sobranEnApi | ForEach-Object { Write-Host "  $_" -ForegroundColor Yellow }
    Write-Host "Agregalos en Services\CatalogoHeroes.cs para que aparezcan." -ForegroundColor Yellow
}
if ($faltanEnApi.Count -gt 0) {
    Write-Host ""
    Write-Host "La app espera heroes que la API ya no devuelve:" -ForegroundColor Yellow
    $faltanEnApi | ForEach-Object { Write-Host "  $_" -ForegroundColor Yellow }
}

$total = (Get-ChildItem $destino -Filter *.png -ErrorAction SilentlyContinue).Count
Write-Host ""
Write-Host "Imagenes en la carpeta: $total" -ForegroundColor Cyan
Write-Host ""
