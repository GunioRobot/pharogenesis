hostWindow: x

	hostWindow _ x.
	self canvas: nil.	"safer to start from scratch"
	self viewBox: hostWindow panelRect.
