exit

	Cursor normal show.	"restore the normal cursor"
	self canvas: nil.		"free my canvas to save space"
	Project current exit.
