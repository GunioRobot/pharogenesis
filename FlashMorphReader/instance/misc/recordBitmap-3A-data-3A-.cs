recordBitmap: id data: aForm
	aForm ifNil:[^self].
	"Record the current form"
	forms at: id put: aForm.
	"Define a new character"
