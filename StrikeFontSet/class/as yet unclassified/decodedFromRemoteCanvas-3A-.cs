decodedFromRemoteCanvas: aString

	| array |
	array _ aString findTokens: #($ ).
	^ self familyName: (array at: 1) size: (array at: 2) asNumber emphasized: (array at: 3) asNumber.
