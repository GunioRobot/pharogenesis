hostWindow: x

	hostWindow _ x.
	worldState canvas: nil.	"safer to start from scratch"
	self viewBox: hostWindow panelRect.
