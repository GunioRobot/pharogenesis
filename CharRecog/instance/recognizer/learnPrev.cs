learnPrev
	"The character recognized before this one was wrong.  (Got here via the gesture for 'wrong'.)  Bring up a dialog box on that char.  8/21/96 tk"

						| old result |
	old _ CharacterDictionary at: prevFeatures ifAbsent: [^ ''].
"get right char from user"	result _ FillInTheBlank request:
						('Redefine the gesture we thought was "', old asString, '".', '
(Letter or:  tab  cr  wrong  bs  select  caret)
', prevFeatures) initialAnswer: '' avoiding: (bmin rounded corner: bmax rounded).

"ignore or..."				(result = '~' | result = '') ifTrue: ['']
"...enter new char"			ifFalse: [
								CharacterDictionary at: prevFeatures 
									put: result].
					"caller erases bad char"
"good char"			^ result