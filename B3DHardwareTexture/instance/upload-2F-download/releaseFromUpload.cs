releaseFromUpload
	"The receiver has been uploaded. Release its bits."
	bits isInteger ifTrue:[^self]. "handled transparently"
	bits _ bits class new.