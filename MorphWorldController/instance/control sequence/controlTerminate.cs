controlTerminate 
	"This window is becoming inactive..."
	Cursor normal show.  "restore the normal cursor"
	model hands do: [:h | h newKeyboardFocus: nil]. "Free dependents links if any"
	model canvas: nil.		"free model's canvas to save space"
	model fullReleaseCachedState 