diffSelection
	"Open a diff browser on the selection."
	
	selection ifNotNil:
		[selection diff]