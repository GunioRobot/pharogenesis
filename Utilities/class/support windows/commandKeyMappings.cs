commandKeyMappings
	^ self class firstCommentAt: #commandKeyMappings

"Lower-case command keys
(use with Cmd key on Mac and Alt key on other platforms)

a	Select all
b	Browse it (selection is a class name)
c	Copy selection
d	Do it (selection is a valid expression)
e	Exchange selection with prior selection
f	Find
g	Find again
h	Set selection as search string for find again
i	Inspect it (selection is a valid expression)
j	Again once
k	Set font
l	Cancel
m	Implementors of it (selection is a message selector)
n	Senders of it (selection is a message selector)
o	Spawn current method
p	Print it (selection is a valid expression)
q	Query symbol (toggle all possible completion for a given prefix)
r	Recognizer
s	Save (i.e. accept)
u	Toggle alignment
v	Paste
w	Delete preceding word
x	Cut selection
y	Swap characters
z	Undo

Note: for Do it, Senders of it, etc., a null selection will be expanded to a word or to the current line in an attempt to do what you want.  Also note that Senders/Implementors of it will find the outermost keyword selector in a large selection, as when you have selected a bracketed expression or an entire line.  Finally note that the same cmd-m and cmd-n (and cmd-v for versions) work in the message pane of most browsers.

Upper-case command keys
(use with Shift-Cmd, or Ctrl on Mac
 or Shift-Alt on other platforms; sometimes Ctrl works too)

A	Advance argument
B	Browse it in this same browser (in System browsers only)
C	Compare argument to clipboard
D	Duplicate
E	Method strings containing it
F	Insert 'ifFalse:'
I	Inspect via Object Explorer
J	Again many
K	Set style
L	Outdent (move selection one tab-stop left)
N	References to it
O	Open single-message browser (in selector lists)
R	Indent (move selection one tab-stap right)
S	Search
T	Insert 'ifTrue:'
U	Convert linefeeds to carriage returns in selection
V	Paste author's initials
W	Selectors containing it
X	Force selection to lowercase
Y	Force selection to uppercase
Z	Capitalize all words in selection

Other special keys

Backspace	Backward delete character
Del			Forward delete character
Shift-Bcksp	Backward delete word
Shift-Del	Forward delete word
Esc			Select current type-in

Cursor keys
left, right,
up, or
down		Move cursor left, right, up or down
Ctrl+Left	Move cursor left one word
Ctrl+Right	Move cursor right one word
Home		Move cursor to begin of line or begin of text
End			Move cursor to end of line or end of text
PgUp, or
Ctrl+Up		Move cursor up one page
PgDown, or
Ctrl+Down	Move cursor down one page

Note all these keys can be used together with Shift to define or enlarge the selection. You cannot however shrink that selection again, which is, compared to other systems, still a limitation aka bug.

Other Cmd-key combinations (does not work on all platforms)

Return		Insert return followed by as many tabs as the previous line
			(with a further adjustment for additional brackets in that line)
Space		Select the current word as with double clicking

Enclose the selection in a kind of bracket.  Each is a toggle.
(does not work on all platforms)
Ctrl-(	Enclose within ( and ), or remove enclosing ( and )
Ctrl-[	Enclose within [ and ], or remove enclosing [ and ]
Crtl-{	Enclose within { and }, or remove enclosing { and }
Ctrl-<	Enclose within < and >, or remove enclosing < and >
Ctrl-'	Enclose within ' and ', or remove enclosing ' and '
Ctrl-""	Enclose within "" and "", or remove enclosing "" and ""

Note also that you can double-click just inside any of the above delimiters (or at the beginning or end of a line) to select the text enclosed.

Text Emphasis...
(does not work on all platforms)
Cmd-1	10 point font
Cmd-2	12 point font
Cmd-3	18 point font
Cmd-4	24 point font
Cmd-5	36 point font
Cmd-6	color, action-on-click, link to class comment, link to method, url
		Brings up a menu.  To remove these properties, select
		more than the active part and then use command-0.
Cmd-7	bold
Cmd-8	italic
Cmd-9	narrow (same as negative kern)
Cmd-0	plain text (resets all emphasis)
Cmd--	underlined (toggles it)
Cmd-=	struck out (toggles it)

Shift-Cmd--	(aka _) negative kern (letters 1 pixel closer)
Shift-Cmd-+	positive kern (letters 1 pixel larger spread)
"