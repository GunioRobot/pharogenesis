form: form mask: mask removeOverlap: remove
	"create a MaskedForm.  If remove is true, remove the colored pixels in this Form from its transparent area.  6/20/96 tk"

	^ self new setForm: form mask: mask removeOverlap: remove