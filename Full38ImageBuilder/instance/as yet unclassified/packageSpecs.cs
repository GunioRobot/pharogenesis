packageSpecs
	"This method will point to the future official package list for 3.8; currently it points just to a private one; see below."

	"self new packageSpecs collect: [:arr |
		(SMSqueakMap default packageWithId: arr first)
releaseWithAutomaticVersionString: arr second]

	(SMSqueakMap default packageWithName: 'Shout') id 
	
     
	"

^self packageSpecsOfficialFor38

"	^self packageSpecsOfficialFor38"