primitiveVersion
	"Return the version of FXBlt"
	interpreterProxy pop: interpreterProxy methodArgumentCount+1.
	interpreterProxy pushInteger: self version.
