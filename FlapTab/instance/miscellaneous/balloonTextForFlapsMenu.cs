balloonTextForFlapsMenu
	"Answer the balloon text to show on a menu item in the flaps menu that governs the visibility of the receiver in the current project"

	| id |
	id _ self flapID.
	#(
	('Squeak'		'Has a few generally-useful controls; it is also a place where you can "park" objects')
	('Tools'			'A quick way to get browsers, change sorters, file lists, etc.')
	('Widgets'		'A variety of controls and media tools')
	('Supplies' 		'A source for many basic types of objects')
	('Stack Tools' 	'Tools for building stacks.  Caution!  Powerful but young and underdocumented')
	('Scripting'		'Tools useful when doing tile scripting')
	('Navigator'		'Project navigator:  includes controls for navigating through linked projects.  Also supports finding, loading and publishing projects in a shared environment')
	('Painting'		'A flap housing the paint palette.  Click on the closed tab to make make a new painting')) do:
		[:pair | (FlapTab givenID: id matches: pair first translated) ifTrue: [^ pair second translated]].

	^ self balloonText