newFromF12File: aFileName
	"StrikeFont newFromF12File: 'kaname.f12'"

	| file n |
	('*.F12' match: aFileName) ifFalse: ["self halt. " "likely incompatible"].
	file _ FileStream readOnlyFileNamed: aFileName.
	file binary.
	n _ self new.
	n name: (FileDirectory baseNameFor: (FileDirectory localNameFor: aFileName)).
	n readF12FromStream: file.
	^ n.
