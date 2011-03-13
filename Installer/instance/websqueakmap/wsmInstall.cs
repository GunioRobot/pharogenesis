wsmInstall 

	| downloadUrl |

	self logCR: 'finding ', self package, ' from websqueakmap(', self wsm, ') ...'.

	downloadUrl := self wsmDownloadUrl.
	
	self logCR: 'found at ', downloadUrl asString, ' ...'.
	 
	self install: downloadUrl from: (self httpGet: downloadUrl).

	