result: aResult from: aResultGenerator 
	"Send aResult of the drop operation computed by aResultGenerator to a   
	resultRecipient, if it exists."
	resultRecipient ifNotNil: [resultRecipient dropResult: aResult from: aResultGenerator]