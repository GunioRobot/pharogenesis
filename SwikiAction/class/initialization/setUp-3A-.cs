setUp: actionName
	"Set up a named Swiki"
	| action map page dir |
	action _ self new.
	map _ URLmap new.
	action map: map.
	action name: actionName.
	action source: 'swiki',(ServerAction pathSeparator).
	map action: action.
	map pages: (Dictionary new).
	map directory: actionName. 
	dir _ FileDirectory on: (ServerAction serverDirectory).
	(dir directoryNames includes: actionName) ifFalse: [
		^ self inform: 'You need to create a folder in Server called ', actionName].
		"A directory in the ServerDirectory for storing pages."
	page _ map newpage: 'Front Page' from: 'Beginning'.
	page text: (HTMLformatter evalEmbedded:
			((FileStream fileNamed: (ServerAction serverDirectory),'swiki',
				(ServerAction pathSeparator),'FrontPage') contentsOfEntireFile) with:
actionName).
	page _ map newpage: 'Formatting Rules' from: 'Beginning'.
	page text: (HTMLformatter evalEmbedded:
			((FileStream fileNamed: (ServerAction serverDirectory),'swiki',
				(ServerAction pathSeparator),'FormattingRules') contentsOfEntireFile)
with: actionName).
	PWS link: actionName to: action.
