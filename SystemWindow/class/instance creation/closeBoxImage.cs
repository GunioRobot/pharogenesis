closeBoxImage
	"Supplied here because we don't necessarily have ComicBold"

	^ CloseBoxImage ifNil: [CloseBoxImage _ (Form
	extent: 9@9
	depth: 16
	fromArray: #( 65537 0 0 1 65536 65537 65536 0 65537 65536 1 65537 1 65537 0 0 65537 65537 65536 0 0 1 65537 0 0 0 65537 65537 65536 0 1 65537 1 65537 0 65537 65536 0 65537 65536 65537 0 0 1 65536)
	offset: 0@0)]