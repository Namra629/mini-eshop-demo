# NGINX Setup (Mini E-Shop)

## NGINX Config Location
/etc/nginx/

Key files:
- nginx.conf → main config
- sites-available/ → available site configs
- sites-enabled/ → active sites (symlinks)
- conf.d/ → additional configs

## Frontend Deployment Path
/var/www/html/

This is where Angular build is deployed.

Files:
- index.html
- main.js
- styles.css

## Request Flow

Browser
  ↓
NGINX (/var/www/html)
  ↓
Static Angular Files

OR

Browser
  ↓
NGINX (/api/*)
  ↓
ASP.NET Core Backend
  ↓
PostgreSQL (via EF Core ORM)
