printViewSpecOn: strm nested: level
	"Print window and viewport specs
	of this and all nested views."
	strm crtab: level; nextPutAll: self class name.
	strm crtab: level; nextPutAll: 'window: '; print: self window.
	strm crtab: level; nextPutAll: 'viewport: '; print: self viewport.
	strm crtab: level; nextPutAll: 'displayBox: '; print: self displayBox.
	strm crtab: level; nextPutAll: 'border: '; print: self borderWidth.
	subViews do: [:v | v printViewSpecOn: strm nested: level+1]