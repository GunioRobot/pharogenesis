resetGrafPort
	"Private! Create a new grafPort for a new copy."

	port _ self portClass toForm: form.
	port clipRect: clipRect.
