setNewContentsFrom: textOrString
	"talk to my text"
	| tm |

	(tm := self findA: TextMorph) ifNil: [^ nil].
	tm valueOfProperty: #cardInstance ifAbsent: ["move it down"
		tm setProperty: #cardInstance toValue: (self valueOfProperty: #cardInstance)].
	tm valueOfProperty: #holdsSeparateDataForEachInstance ifAbsent: ["move it down"
		tm setProperty: #holdsSeparateDataForEachInstance toValue: 
			(self valueOfProperty: #holdsSeparateDataForEachInstance)].
	^ tm setNewContentsFrom: textOrString