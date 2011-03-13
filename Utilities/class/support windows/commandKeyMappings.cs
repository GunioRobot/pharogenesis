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

esc	Select current type-in

[	Enclose within [ and ], or remove enclosing [ and ]
(	Enclose within ( and ), or remove enclosing ( and )   NB: use ctrl (
{	Enclose within { and }, or remove enclosing { and }
<	Enclose within < and >, or remove enclosing < and >
'	Enclose within ' and ', or remove enclosing ' and '
""	Enclose within "" and "", or remove enclosing "" and ""

0	10 point plain serif
1	10 point bold serif
2	10 point italic serif

3	12 point plain serif
4	12 point bold serif
5	12 point italic serif

6	10 point plain sans-serif
7	10 point bold sans-serif

8	10 point underline serif
9	12 point plain sans-serif

"
	
"Answer a string to be presented in a window at user request as a crib sheet for command-key mappings.  2/7/96 sw
5/1/96 sw: modified so that the long string lives in a comment, hence doesn't take up memory.  Also, fixed up some of the actual text, and added help for parentheses-enclosing items and text-style controls.
5/10/96 sw: added a bunch of changes at JM's suggestion
8/11/96 sw: fixed the font sizes, added align & references to it, and help for cmd-shift-B"