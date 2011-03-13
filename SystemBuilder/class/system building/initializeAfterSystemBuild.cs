initializeAfterSystemBuild
	"Reinitialize needs to be called manually after filing in the kernel because other support classes need to have been filed in before it can run successfully.  This method copied over from old macPal stuff, 1/27/96 sw, to serve as a template, but the real work needs to be done still."

	Text initTextConstants.
	
	"Rebuild snapshot lists"

	self showInTranscript: '** SystemBuilder reinitialize  **'.
	self initMenus