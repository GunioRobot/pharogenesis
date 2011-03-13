showInTranscript: aString
	"Call this instead of addressing Transcript directly in order to ease identification of all New-Kernel-related Transcript calls obtained (i.e. by browsing senders).  1/18/96 sw"

	Transcript cr; show: aString