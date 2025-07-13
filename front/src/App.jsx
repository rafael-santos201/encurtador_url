import { useState } from 'react'

export default function App() {
  const [originalUrl, setOriginalUrl] = useState('')
  const [shortUrl, setShortUrl] = useState('')
  const [error, setError] = useState('')
  const [loading, setLoading] = useState(false)

  async function handleSubmit(e) {
    e.preventDefault()
    setError('')
    setShortUrl('')

    if (!originalUrl.trim()) {
      setError('Por favor, insira uma URL válida.')
      return
    }

    setLoading(true)

    try {
      const response = await fetch('http://localhost:5285/encurtador_url/shorten', {
        method: 'POST',
        headers: { 'Content-Type': 'application/json' },
        body: JSON.stringify({ originalUrl }),
      })

      if (!response.ok) {
        const data = await response.json()
        setError(data || 'Erro desconhecido')
      } else {
        const data = await response.json()
        setShortUrl(data.shortUrl)
      }
    } catch (err) {
      setError('Erro ao conectar com a API.')
    } finally {
      setLoading(false)
    }
  }

  return (
    <div className="min-h-screen flex items-center justify-center bg-gradient-to-br from-blue-100 via-white to-purple-200 px-4">
      <div className="bg-white shadow-xl rounded-2xl p-8 w-full max-w-xl">
        <h1 className="text-3xl font-bold text-center mb-6 text-blue-700">Encurtador de URL</h1>

        <form onSubmit={handleSubmit} className="space-y-4">
          <input
            type="url"
            placeholder="Cole a URL aqui"
            value={originalUrl}
            onChange={(e) => setOriginalUrl(e.target.value)}
            className="w-full p-3 border border-gray-300 rounded-lg focus:outline-none focus:ring-2 focus:ring-blue-500"
            required
          />
          <button
            type="submit"
            disabled={loading}
            className="w-full py-3 bg-blue-600 text-white font-semibold rounded-lg hover:bg-blue-700 transition disabled:opacity-50"
          >
            {loading ? 'Encurtando...' : 'Encurtar'}
          </button>
        </form>

        {error && <p className="text-red-600 text-center mt-4">{error}</p>}

        {shortUrl && (
          <div className="mt-6 text-center">
            <p className="text-gray-700 mb-2">URL encurtada:</p>
            <a
              href={shortUrl}
              target="_blank"
              rel="noopener noreferrer"
              className="text-blue-600 underline break-words"
            >
              {shortUrl}
            </a>
          </div>
        )}
      </div>
    </div>
  )
}
