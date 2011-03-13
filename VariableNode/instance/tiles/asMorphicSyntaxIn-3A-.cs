asMorphicSyntaxIn: parent

	^ parent addToken: name
			type: #variable 
			on: self clone	"don't hand out the prototype! See VariableNode>>initialize"
