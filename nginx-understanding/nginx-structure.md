
## NGINX Configuration (Real VM Setup)

NGINX is used in this project as a **Static Web Server + Reverse Proxy**.

---

## 📍 Main Config Location

/etc/nginx

/etc/nginx/nginx.conf  -> main config
/etc/nginx/sites-available/default  -> avb site configs
/etc/nginx/sites-enabled/ -> active sites (symlinks)

---

## 📁 Static Frontend Hosting (Angular)

NGINX serves the Angular build from:

/var/www/html

Example files:
- index.html
- main.js
- styles.css

---

## ⚙️ Server Block Configuration

NGINX listens on port 80 and handles both frontend and backend routing.

```nginx
server {
    listen 80;
    server_name _;

    root /var/www/html;
    index index.html;

    location / {
        try_files $uri $uri/ /index.html;
    }

    # Reverse Proxy for API requests
    location /api/ {
        proxy_pass http://localhost:5006;

        proxy_http_version 1.1;

        proxy_set_header Host $host;
        proxy_set_header X-Real-IP $remote_addr;
        proxy_set_header X-Forwarded-For $proxy_add_x_forwarded_for;
        proxy_set_header X-Forwarded-Proto $scheme;
    }
}


## Request Flow

Browser -> NGINX (/var/www/html) -> Static Angular Files

Browser → NGINX (/api/*) → ASP.NET Core API  → PostgreSQL (via EF Core ORM)

