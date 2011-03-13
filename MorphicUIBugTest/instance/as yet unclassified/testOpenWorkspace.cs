testOpenWorkspace
"self new testOpenWorkspace"
"MorphicUIBugTest run: #testOpenWorkspace"

| window myLabel foundWindow myModel |

self assert: ( Smalltalk isMorphic ) .

myLabel := 'Workspace from ', 'SUnit test' .
foundWindow := self findWindowInWorldLabeled: myLabel .
self assert: ( foundWindow isNil ) .

window := 
UIManager default edit: '"MorphicUIBugTest run: #openWorkspaceTest"'  label: myLabel .

window = window. 

foundWindow := self findWindowInWorldLabeled: myLabel .

cases := Array with: foundWindow . "For teardown."

myModel := (foundWindow submorphs detect: [ :each |
	each isMorphicModel ] )  .

self assert: ( myModel model class == Workspace ) .
self assert: ( foundWindow model class == Workspace ) .

foundWindow delete .