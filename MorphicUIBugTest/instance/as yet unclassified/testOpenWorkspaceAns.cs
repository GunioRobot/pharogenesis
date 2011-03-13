testOpenWorkspaceAns
"Test if method opening a workspace answers the window opened"

"MorphicUIBugTest run: #testOpenWorkspaceAns"


| window myLabel foundWindow |

self assert: ( Smalltalk isMorphic ) .

myLabel := 'Workspace from ', 'SUnit test' .
foundWindow := self findWindowInWorldLabeled: myLabel .
self assert: ( foundWindow isNil ) .

window := 
UIManager default edit: '"MorphicUIBugTest run: #openWorkspaceTest"'  label: myLabel .

foundWindow := self findWindowInWorldLabeled: myLabel .

cases := Array with: foundWindow . "For teardown."

self assert: ( window == foundWindow ) .

foundWindow delete .