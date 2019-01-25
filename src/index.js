import * as p5 from '@code-dot-org/p5'
import '@code-dot-org/p5.play/lib/p5.play.js'

let s = (sk) => {    
    sk.setup = () => {
        sk.createCanvas(window.innerWidth,window.innerHeight);
        sk.background(40);
        sk.stroke(200);
        sk.strokeWeight(3);
        sk.createCanvas(800,400);
        sk.createSprite(400, 200, 50, 50);
    }
    sk.draw = () => {
        sk.background(255,255,255);  
        sk.drawSprites();
    }
}

const P5 = new p5(s);

if (module.hot) {
  module.hot.accept()
}