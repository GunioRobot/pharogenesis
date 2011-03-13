fillRectangle: aRect color: aColor 
	"fills an area of the display with the given color"
	| brush |
	 
	brush _ Win32HBrush createSolidBrush: aColor asColorref.
	self
		apiFillRect: self
		with: (Win32Rectangle fromRectangle: aRect)
		with: brush.
	brush delete