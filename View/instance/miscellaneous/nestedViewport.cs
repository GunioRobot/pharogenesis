nestedViewport

	"The viewport size used to control scaling of nested user views."

	^ (0@0 extent: self viewport extent)
			insetBy: 16 @ 16