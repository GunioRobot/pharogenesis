platformAbsoluteDirectories
	| answer dir path |
	
	answer := OrderedCollection new.
	SmalltalkImage current platformName = 'Win32'
		ifTrue:[
			path := self getWindowsFontFolderPath.
			(path notNil and:[(dir := FileDirectory on: path) exists])
				ifTrue:[answer add: dir]].
	SmalltalkImage current platformName = 'unix'
		ifTrue:[
			self getUnixFontFolderPaths do:[:each |
				(dir := FileDirectory on: each) exists
					ifTrue:[answer add: dir]]].
	SmalltalkImage current platformName = 'Mac OS'
		ifTrue:[
			SmalltalkImage current osVersion asNumber >= 1000
				ifTrue:["OS X"
					self getMacOSXFontFolderPaths do:[:each |
						(dir := FileDirectory on: each) exists
							ifTrue:[answer add: dir]]]].
	^answer