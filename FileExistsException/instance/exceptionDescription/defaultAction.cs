defaultAction
	"The default action taken if the exception is signaled."

	^StandardFileStream fileExistsUserHandling: self fileName
