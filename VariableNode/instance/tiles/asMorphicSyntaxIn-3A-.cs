asMorphicSyntaxIn: parent

	^ parent addToken: self name
			type: #variable 
			on: self clone	"don't hand out the prototype! See VariableNode>>initialize"
