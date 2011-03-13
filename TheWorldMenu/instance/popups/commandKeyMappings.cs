commandKeyMappings
	^ (self class firstCommentAt: #commandKeyMappings) translated

"Lower-case command keys
(use with Cmd key on Mac and Alt key on other platforms)
a	Select all
b	Browse it (selection is a class name or cursor is over a class-list or message-list)
c	Copy selection
d	Do it (selection is a valid expression)
e	Method strings containing it (case insensitive)
f	Find
g	Find again
h	Set selection as search string for find again
i	Inspect it (selection is a valid expression, or selection is over an inspect-ilst)
j	Again once (do the last text-related operation again)
k	Set font
l	Cancel
m	Implementors of it (selection is a message selector or cursor is over a class-list or message-list)
n	Senders of it (selection is a message selector or cursor is over a class-list or message-list)
o	Spawn current method
p	Print it (selection is a valid expression)
q	Query symbol (toggle all possible completion for a given prefix)
r	Recognizer
s	Save (i.e. accept)
t	Finds a Transcript (when cursor is over the desktop)
u	Toggle alignment
v	Paste
w	Delete preceding word (over text);  Close-window (over morphic desktop)
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
D	Debug it
E	Method strings containing it (case sensitive)
F	Insert 'ifFalse:'
G	fileIn from it (a file name)
H	cursor TopHome:
I	Inspect via Object Explorer
J	Again many (apply the previous text command repeatedly until the end of the text)
K	Set style
L	Outdent (move selection one tab-stop left)
M	Select current type-in
N	References to it (selection is a class name, or cursor is over a class-list or message-list)
O	Open single-message browser (in message lists)
P	Make project link
R	Indent (move selection one tab-stap right)
S	Search
T	Insert 'ifTrue:'
U	Convert linefeeds to carriage returns in selection
V	Paste author's initials
W	Selectors containing it (in text); show-world-menu (when issued with cursor over desktop)
X	Force selection to lowercase
Y	Force selection to uppercase
Z	Capitalize all words in selection

Other special keys
Backspace	Backward delete character
Del			Forward delete character
Shift-Bksp	Backward delete word
Shift-Del	Forward delete word
Esc			Pop up the Desktop Menu
\			Send top window to back

Cursor keys
left, right,
up, down	Move cursor left, right, up or down
Ctrl-left		Move cursor left one word
Ctrl-right	Move cursor right one word
Home		Move cursor to begin of line or begin of text
End			Move cursor to end of line or end of text
PgUp, Ctrl-up	Move cursor up one page
PgDown, Ctrl-Dn	Move cursor down one page

Note all these keys can be used together with Shift to define or enlarge the selection. You cannot however shrink that selection again, as in some other systems.

Other Cmd-key combinations (not available on all platforms)
Return		Insert return followed by as many tabs as the previous line
			(with a further adjustment for additional brackets in that line)
Space		Select the current word as with double clicking

Enclose the selection in a kind of bracket.  Each is a toggle.
	(not available on all platforms)
Ctrl-(	Enclose within ( and ), or remove enclosing ( and )
Ctrl-[	Enclose within [ and ], or remove enclosing [ and ]
Crtl-{	Enclose within { and }, or remove enclosing { and }
Ctrl-<	Enclose within < and >, or remove enclosing < and >
Ctrl-'	Enclose within ' and ', or remove enclosing ' and '
Ctrl-""	Enclose within "" and "", or remove enclosing "" and ""
Note also that you can double-click just inside any of the above delimiters,
or at the beginning or end of a line, to select the text enclosed.

Text Emphasis
	(not available on all platforms)
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

Shift-Cmd--	(aka :=) negative kern (letters 1 pixel closer)
Shift-Cmd-+	positive kern (letters 1 pixel larger spread)
"