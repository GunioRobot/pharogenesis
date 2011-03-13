openOnForm: aForm
	"Create and schedule an instance of me on the form aForm."

	| topView |
	topView := self createOnForm: aForm.
	topView controller open

