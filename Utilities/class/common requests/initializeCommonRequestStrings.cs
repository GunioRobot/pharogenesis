initializeCommonRequestStrings
	"Initialize an array of common request strings.  2/1/96 sw
	 5/10/96 sw: converted over to new format of StringHolder"

	CommonRequestStrings _ StringHolder new contents: 
'Sensor keyboard
Curor normal show
Transcript cr; show: ''testing''
Smalltalk sendersOf: #hot
Utilities emergencyCollapse
CharRecog reinitializeCharacterDictionary'

"Utilities initializeCommonRequestStrings"