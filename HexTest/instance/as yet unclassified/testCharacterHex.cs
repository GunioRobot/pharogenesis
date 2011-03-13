testCharacterHex
| result |
result _ $a hex.
self assert: result = '61'.
result _ $A hex.
self assert: result = '41'.


