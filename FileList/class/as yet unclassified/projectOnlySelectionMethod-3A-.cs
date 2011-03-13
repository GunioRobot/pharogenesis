projectOnlySelectionMethod: incomingEntries

	| versionsAccepted basicInfoTuple basicName basicVersion |

	"this shows only the latest version of each project"
	versionsAccepted := Dictionary new.
	incomingEntries do: [ :entry |
		entry isDirectory ifFalse: [
			(#('*.pr' '*.pr.gz' '*.project') anySatisfy: [ :each | each match: entry name]) ifTrue: [
				basicInfoTuple := Project parseProjectFileName: entry name.
				basicName := basicInfoTuple first.
				basicVersion := basicInfoTuple second.
				((versionsAccepted includesKey: basicName) and: 
						[(versionsAccepted at: basicName) first > basicVersion]) ifFalse: [
					versionsAccepted at: basicName put: {basicVersion. entry}
				].
			]
		]
	].
	^versionsAccepted asArray collect: [ :each | each second]