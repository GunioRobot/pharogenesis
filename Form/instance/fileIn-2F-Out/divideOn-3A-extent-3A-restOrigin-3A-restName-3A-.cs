divideOn: stream extent: ext restOrigin: restOrigin restName: name
	"Divide self to fit in MacPaint file along width or height."
	| form newStream |
	form _ Form extent: ext.
	form copy: (0@0 extent: form extent)
			from: 0@0
			in: self rule: Form over.
	form bigMacPaintOn: stream.
	stream close.
	form _ Form extent: self extent - restOrigin.
	form copy: (0@0 extent: form extent)
			from: restOrigin
			in: self rule: Form over.
	newStream _ FileStream fileNamed: stream fileName, name.
	form bigMacPaintOn: newStream.
	newStream close.
