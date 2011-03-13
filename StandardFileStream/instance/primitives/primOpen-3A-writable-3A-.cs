primOpen: fileName writable: aBoolean
	"Open a file of the given name, and return the file id obtained.
	If writable is true, then
		if there is none with this name, then create one
		else prepare to overwrite from the beginning
	otherwise open readonly,
		or return nil if there is no file with this name"

	<primitive: 153>
	^ nil