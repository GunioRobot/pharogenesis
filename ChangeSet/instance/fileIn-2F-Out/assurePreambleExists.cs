assurePreambleExists
	"Make sure there is a StringHolder holding the preamble; if it's found to have reverted to empty contents, put up the template"

	(preamble == nil or: [preamble contents isEmptyOrNil])
		ifTrue: [preamble _ StringHolder new contents: self preambleTemplate]