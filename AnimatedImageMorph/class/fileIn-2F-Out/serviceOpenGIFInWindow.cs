serviceOpenGIFInWindow
	"Answer a service for opening a gif graphic in a window"

	^ (SimpleServiceEntry 
		provider: self 
		label: 'open graphic in a window'
		selector: #openGIFInWindow:
		description: 'open a GIF graphic file in a window'
		buttonLabel: 'open')
		argumentGetter: [ :fileList | fileList readOnlyStream ]