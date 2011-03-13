updateFrom7025

	"self new updateFrom7025"
	"
	NOT RELEASED YET
	---------------------------------
	See Mantis bug 1840 and 854.
	This changeset allows a too-long Delay to fail the relevant primitive and schedules a fake 	delay to keep the timer system going. I claim this is preferable to disallowing long delays.
	---------------------------------
	3515 - Parser fails in #defineClass: becasue Metaclass doest not understand #category
	---------------------------------
	003513: [ENH] ToolBuilderBldEnh-KR
Description
ToolBuilder>>(class)build: 
enable default builder to build objects without opening.
It's useful for building authoring prototypes for ToolBuilder-based tools in parts bin.
	---------------------------------
	0003510: In 3.9a requesting a language change leads to infinite generation of testRunners
	---------------------------------
	0003504: Float asInteger conversion is inexact...
	"
	self script60.
	self flushCaches.
	MCDefinition clearInstances.
	