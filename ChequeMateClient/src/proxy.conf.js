const PROXY_CONFIG = [
  {
    context: [
      "/api/invoices",
    ],
    target: "https://localhost:7006",
    secure: false
  }
]

module.exports = PROXY_CONFIG;
