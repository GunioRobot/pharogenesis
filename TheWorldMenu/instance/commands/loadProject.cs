loadProject

	| stdFileMenuResult |
	"Put up a Menu and let the user choose a '.project' file to load.  Create a thumbnail and jump into the project."

	Project canWeLoadAProjectNow ifFalse: [^ self].
	stdFileMenuResult _ ((StandardFileMenu new) pattern: '*.pr'; 
		oldFileFrom: FileDirectory default ) 
			startUpWithCaption: 'Select a File:' translated.
	stdFileMenuResult ifNil: [^ nil].
	ProjectLoading 
		openFromDirectory: stdFileMenuResult directory 
		andFileName: stdFileMenuResult name
