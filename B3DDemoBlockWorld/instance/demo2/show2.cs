show2

    " B3DDemoBlockWorld new show2"

     | view |

  self createScene2.
  (view := B3DTutorialScenePresenterMorph new)
    source: self description: #descriptionScene2;
    scene: scene.
  view clearColor: (Color gray: 0.7).

  view panBy: (10@10@10);
       addDolly: 1.0;
       rotateY: 10.

  view openInSystemWindow.