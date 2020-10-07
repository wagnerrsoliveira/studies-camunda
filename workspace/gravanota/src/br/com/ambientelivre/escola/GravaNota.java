package br.com.ambientelivre.escola;

import org.camunda.bpm.engine.delegate.DelegateExecution;
import org.camunda.bpm.engine.delegate.JavaDelegate;

public class GravaNota implements JavaDelegate {
	
	public void execute(DelegateExecution execution) throws Exception {
		
		//try {
			long nota = (long) execution.getVariableLocal("nota");
			nota = nota +1;
			execution.setVariable("nota", nota);
		//}  throw new RuntimeException("deu erro!");
		
		
	}

}