copyFrom: aForm
	"Take on all state of aForm, with complete sharing"

	super copyFrom: aForm.
	clippingBox _ super boundingBox