commandKeyMappings
	^ self class firstCommentAt: #commandKeyMappings

"Lower-case command keys
a	Select all
b	Browse it
c	Copy
d	Do it
e	Exchange
f	Find
g	Find again
h	Set Search String
i	Inspect it
j	Again once
k	Set font
l	Cancel
m	Implementors of it
n	Senders of it
o	Spawn
p	Print it
q	Query symbol
r	Recognizer
s	Save (i.e. accept)
u	Align
v	Paste
w	Delete preceding word
x	Cut
y	Swap characters
z	Undo

Upper-case command keys (Hold down Cmd & Shift, or Ctrl key)
A	Advance argument
B	Browse it in this same browser (in System browsers only)
C	Compare argument to clipboard
D	Duplicate
E	Method strings containing it
F	Insert 'ifFalse:'
J	Again many
K	Set style
L	Outdent (move selection one tab-stop left)
N	References to it
R	Indent (move selection one tab-stap right)
S	Search
T	Insert 'ifTrue:'
W	Selectors containing it
V	Paste author's initials
<return>		Insert return followed by as many tabs as the previous line
			(with a further adjustment for additional brackets in that line)

esc			Select current type-in
shift-delete	Forward delete character

Enclose the selection in a kind of bracket.  Each is a toggle.
Control-(	Enclose within ( and ), or remove enclosing ( and )
[	Enclose within [ and ], or remove enclosing [ and ]
{	Enclose within { and }, or remove enclosing { and }
<	Enclose within < and >, or remove enclosing < and >
'	Enclose within ' and ', or remove enclosing ' and '
""	Enclose within "" and "", or remove enclosing "" and ""
(Double click just inside any of the above delimiters to select the text inside it.)

Text Emphasis...
1	10 point font
2	12 point font
3	18 point font  (not in base image)
4	24 point font  (not in base image)
5	36 point font  (not in base image)

6	color, action-on-click, link to class comment, link to method, url
	Brings up a menu.  To remove these properties, select
	more than the active part and then use command-0.

7	bold
8	italic
9	narrow (same as negative kern)
0	plain text (resets all emphasis)
-	underlined (toggles it)
=	struck out (toggles it)

Cmd-shift
_ (aka shift -)	negative kern (letters 1 pixel closer)
+		positive kern (letters 1 pixel larger spread)
"
