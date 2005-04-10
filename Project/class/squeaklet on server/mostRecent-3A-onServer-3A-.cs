mostRecent: projName onServer: aServerDirectory
	| stem list max goodName triple num stem1 stem2 rawList nothingFound unEscName |
	"Find the exact fileName of the most recent version of project with the stem name of projName.  Names are of the form 'projName|mm.pr' where mm is a mime-encoded integer version number.
	File names may or may not be HTTP escaped, %20 on the server."

	self flag: #bob.		"do we want to handle unversioned projects as well?"

	nothingFound _ {nil. -1}.
	aServerDirectory ifNil: [^nothingFound].
	"23 sept 2000 - some old projects have periods in name so be more careful"
	unEscName _ projName unescapePercents.
	triple _ Project parseProjectFileName: unEscName.
	stem _ triple first.
	rawList _ aServerDirectory fileNames.

	rawList isString ifTrue: [self inform: 'server is unavailable'. ^nothingFound].
	list _ rawList collect: [:nnn | nnn unescapePercents].
	max _ -1.  goodName _ nil.
	list withIndexDo: [:aName :ind |
		(aName beginsWith: stem) ifTrue: [
			num _ (Project parseProjectFileName: aName) second.
			num > max ifTrue: [max _ num.  goodName _ (rawList at: ind)]]].

	max = -1 ifFalse: [^ Array with: goodName with: max].

	"try with underbar for spaces on server"
	(stem includes: $ ) ifTrue: [
		stem1 _ stem copyReplaceAll: ' ' with: '_'.
		list withIndexDo: [:aName :ind |
			(aName beginsWith: stem1) ifTrue: [
				num _ (Project parseProjectFileName: aName) second.
				num > max ifTrue: [max _ num.  goodName _ (rawList at: ind)]]]].
	max = -1 ifFalse: [^ Array with: goodName with: max].
	
	"try without the marker | "
	stem1 _ stem allButLast, '.pr'.
	stem2 _ stem1 copyReplaceAll: ' ' with: '_'.	"and with spaces replaced"
	list withIndexDo: [:aName :ind |
		(aName beginsWith: stem1) | (aName beginsWith: stem2) ifTrue: [
			(triple _ aName findTokens: '.') size >= 2 ifTrue: [
				max _ 0.  goodName _ (rawList at: ind)]]].	"no other versions"
	max = -1 ifFalse: [^ Array with: goodName with: max].

	^nothingFound		"no matches"
