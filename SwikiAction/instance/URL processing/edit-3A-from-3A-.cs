edit: pageRef from: request
	request reply: (HTMLformatter evalEmbedded:
							(self fileContents:
source , 'edit.html')
						with: pageRef).
	pageRef noteEditRequest.
	^ self