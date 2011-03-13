initializeHelpStrings
	"ScriptingSystem initializeHelpStrings"
	HelpStrings _ IdentityDictionary new.
	#(
(heading		number		
'Which direction the object is
facing.  0 is straight up') 

(x				number		
'The x coordinate, measured from 
the left of the container')

(y				number
'The y-coordinate, measured upward
from the bottom of the container')

(colorUnder		color
'The color under the
center of the object')

(penDown		boolean
'Whether the object''s pen
is down (true) or up (false)')

(penColor		color
'The color of the object''s pen')

(penSize			number
'The size of the object''s pen')

(colorSees		boolean
'Whether a given color in the
object is over another given color')

(scaleFactor		number
'The amount by which
the object is scaled')

(width			number
'The distance between the
left and right edges of the object')

(height			number
'The distance between the
top and bottom edges of the object')

(isOverColor		color
'Whether the object is
over the given color')

(color			color
'The object''s interior color')

(borderWidth	number
'The width of the object''s border')

(borderColor		color
'The color of the object''s border')

(cursor			number
'The index of the chosen element')

(valueAtCursor	player
'The chosen element')

(leftRight		number
'The horizontal displacement')

(upDown		number
'The vertical displacement')

(angle			number
'The angular displacement')

(amount		number
'The amount of displacement')

(mouseX		number
'The x coordinate of
the mouse pointer')

(mouseY		number
'The y coordinate of
the mouse pointer')

(left		number
'My left edge, measured from
the left edge of the World')

(right		number
'My right edge, measured from
the left edge of the world')

(top		number
'My top edge, measured downward
from the top edge of the world')

(bottom		number
'My bottom edge, measured downward
from the top edge of the world')

(tryMe			command
'Click here to run this script once;
hold button down to run repeatedly.')

(try			command
'Click here to run this command once,
with parameters as seen right here.
Hold button down to run repeatedly')

(dismiss			command
'Click here to dismiss me')

(addYesNoToHand	command
'Press here to tear off a 
TEST/YES/NO unit which
you can drop into your script')

(chooseTrigger	command
'Press here to choose when
this script should be run')

(offerScriptorMenu	command
'Press here to get a menu of
options for this Scriptor')

(objectNameInHalo  control
'Object''s name -- To change:
click here; backspace over old name,
type in new name; hit ENTER')

(userSlot		control
'This is an instance variable
defined by you.  Click here to
change its type')

		) do: [:triplet | HelpStrings at: triplet first put: triplet third]