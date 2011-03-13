openOnForm: aForm at: magnifiedLocation 
	"Create and schedule a BitEditor on the form aForm at magnifiedLocation. 
	Show the small and magnified view of aForm."

	^self openOnForm: aForm
		at: magnifiedLocation
		scale: 8 @ 8